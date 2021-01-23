    namespace UnitTestProject
    {
        using FluentAssertions;
        using Ninject;
        using Ninject.Extensions.DependencyCreation;
        using Ninject.Extensions.NamedScope;
        using Ninject.Infrastructure.Disposal;
        using System;
        using Xunit;
        public class UnitTest1
        {
            [Fact]
            public void TestMethod()
            {
                // Arrange
                var kernel = new StandardKernel();
                const string namedScope = "namedScope";
                kernel.Bind<View>().ToSelf()
                    .DefinesNamedScope(namedScope);
                kernel.DefineDependency<View, Presenter>();
                kernel.Bind<ViewModel>().ToSelf().InNamedScope(namedScope);
                Presenter presenterInstance = null;
                kernel.Bind<Presenter>().ToSelf()
                    .WithCreatorAsConstructorArgument("view")
                    .OnActivation(x => presenterInstance = x);
                var view = kernel.Get<View>();
                // named scope should result in presenter and view getting the same view model instance
                presenterInstance.Should().NotBeNull();
                view.ViewModel.Should().BeSameAs(presenterInstance.ViewModel);
                // disposal of named scope root should clear all strong references which ninject maintains in this scope
                view.Dispose();
                kernel.Release(view.ViewModel).Should().BeFalse();
                kernel.Release(view).Should().BeFalse();
                kernel.Release(presenterInstance).Should().BeFalse();
                kernel.Release(presenterInstance.View).Should().BeFalse();
            }
        }
        public class View : INotifyWhenDisposed
        {
            public View()
            {
            }
            public View(ViewModel viewModel)
            {
                ViewModel = viewModel;
            }
            public event EventHandler Disposed;
            public ViewModel ViewModel { get; private set; }
            public bool IsDisposed { get; private set; }
            public void Dispose()
            {
                if (!this.IsDisposed)
                {
                    this.IsDisposed = true;
                    var handler = this.Disposed;
                    if (handler != null)
                    {
                        handler(this, EventArgs.Empty);
                    }
                }
            }
        }
        public class ViewModel
        {
        }
        public class Presenter
        {
            public View View { get; set; }
            public ViewModel ViewModel { get; set; }
            public Presenter(View view, ViewModel viewModel)
            {
                View = view;
                ViewModel = viewModel;
            }
        }
    }
