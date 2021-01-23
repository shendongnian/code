	void Main()
	{
		var _SolutionEvents = new Foo();
	
		var opened = Observable.FromEvent<_dispSolutionEvents_OpenedEventHandler, Unit>(h => () => h(Unit.Default), h => _SolutionEvents.Opened += h, h => _SolutionEvents.Opened -= h);
	
		opened.Subscribe(x => Console.WriteLine("Opened"));
	
		_SolutionEvents.OnOpened();
	}
	
	public delegate void _dispSolutionEvents_OpenedEventHandler();
	
	public class Foo
	{
		public event _dispSolutionEvents_OpenedEventHandler Opened;
	
		public void OnOpened()
		{
			this.Opened?.Invoke();
		}
	}
