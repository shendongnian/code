    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Reactive.Testing;
    using NUnit.Framework;
    namespace StackOverflow.Q36340516_BufferedByBoundary
    {
        [TestFixture]
        public class BufferByBoundary : ReactiveTest
        {
            [Test]
            public void Should_yield_only_text_between_KeyPress_Boundary_events()
            {
                var scheduler = new TestScheduler();
                var observer = scheduler.CreateObserver<string>();
                //var keyDown = Observable.FromEventPattern<KeyEventArgs>(this, "PreviewKeyDown");
                //var boundaryEvent = keyDown.Buffer(2, 1)
                //    //Only yield the pair of events if the pair is LeftShift and OemPlus
                //    .Where(buffer =>
                //        buffer[0].EventArgs.Key == Key.LeftShift
                //        && buffer[1].EventArgs.Key == Key.OemPlus)
                //    .Select(_=>Unit.Default);
                var boundaryEvent = scheduler.CreateHotObservable(
                    OnNext(0150, Unit.Default), //open
                    OnNext(0350, Unit.Default), //close
                    OnNext(0550, Unit.Default), //open
                    OnNext(0850, Unit.Default)); //close
                //var textInput = Observable.FromEventPattern<TextCompositionEventArgs>(this, "PreviewTextInput")
                //      .Select(evt=>evt.EventArgs.Text);
                var textInput = scheduler.CreateHotObservable(
                    OnNext(00100, "A"),     //before 1st open
                    OnNext(00200, "B"),     //buffer 1
                    OnNext(00300, "C"),     //buffer 1
                    OnNext(00400, "D"),
                    OnNext(00500, "E"),
                    OnNext(00600, "F"),     //buffer 2
                    OnNext(00700, "G"),     //buffer 2
                    OnNext(00800, "H")      //buffer 2
                    );
                var query = from start in boundaryEvent.Take(1)
                            from text in textInput.Buffer(() => boundaryEvent)
                            select string.Join(string.Empty, text);
                query.Take(1).Repeat().Subscribe(observer);
                scheduler.Start();
                CollectionAssert.AreEqual(new[]
                {
                    OnNext(350, "BC"),
                    OnNext(850, "FGH"),
                },
                observer.Messages);
            }
        }
    }
