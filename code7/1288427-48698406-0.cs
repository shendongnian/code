	using System;
	using System.Diagnostics;
	class Program { static void Main() => new _derived(); }
	abstract class _base
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Object trace;
	};
	class _derived : _base
	{
		public _derived() => Debugger.Break();      // <-- vs2017 EE crash when stopped here
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		new public Object trace => base.trace;
	}
