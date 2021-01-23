	// ---------- Views ----------
	// TODO: Replace with your platform-specific View base class.
	internal class View
	{
		
	}
	// Each View class has access to its ViewModel class, and sometimes to other View classes.
	// If a View1 needs to alter a ViewModel belonging to another View2, this should be via custom methods on View2,
	// or perhaps via a limited Interface onto ViewModel2.
	// E.g., to build the initial state of a View2 that we are segueing to.
	internal class View1 : View, VM1.IOwner
	{
		private VM1 vm;
		// TODO: Replace this with access to a textbox in your UI.
		private string _text1;
		public string Text1
		{
			get { return _text1; }
			set { _text1 = value; }
		}
		// TODO: Replace these with platform-specific methods for page appearing, disappearing.
		public void OnLoad()
		{
			vm = new VM1(this);
			vm.Load();
		}
		public void OnStore()
		{
			vm.Store();
		}
		// Example of "building" the input to a following view.
		public void OnSegue(View nextView)
		{
			var nextView2 = nextView as View2;
			if (nextView2 != null)
				nextView2.IncomingA = vm.CurrentA;
		}
		// --- represents a method used within view's workflow. ---
		public void SomeMethod()
		{
			// E.g., based on user selection, make a specified ModelA be "current".
			// (In practice, it would take a more complex scenario for view to want to hold an IModelA.)
			// (In this simple case, View could hold an index, call SetCurrentModelAByIndex, not need an IModelA object.)
			IModelA desiredA = vm.GetOneModelA(1);
			if (desiredA != null)
				vm.CurrentA = desiredA;
			else
			{
				// ... message to user ...
			}
		}
	}
	internal class View2 : View //TODO , VM2.IOwner
	{
		internal IModelA IncomingA;
        // ...
	}
	// ---------- ViewModels ----------
	// Each of these corresponds to a single view. So "VM1" corresponds to "V1".
	// ViewModel classes have access to Model classes.
	internal class VM1
	{
		// This gives a limited way for VM1 to "call back" to its V1.
		internal interface IOwner
		{
			string Text1 { get; set; }
		}
		private readonly IOwner _owner;
		private ModelA _a;
		private IList<ModelA> someAs;
		internal VM1(IOwner owner)
		{
			_owner = owner;
		}
		internal void Load()
		{
			// TODO: Replace this with logic that is told (or "knows") where to get the active Models.
			someAs = new List<ModelA> {new ModelA(), new ModelA()};
			_a = (someAs.Count > 0 ? someAs[0] : null);
			_owner.Text1 = (_a != null ? _a.TextA : "No ModelA");
		}
		// View is only allowed to know about "IModelA", not "ModelA".
		internal IModelA GetOneModelA(int index)
		{
			if (index < someAs.Count)
				return someAs[index];
			else
				return null;
		}
		// Return "true" if succeeds.
		internal bool SetCurrentModelAByIndex(int index)
		{
			IModelA desiredA = GetOneModelA(1);
			if (desiredA != null)
			{
				SetCurrentModelA(desiredA);
				return true;
			}
			else
				return false;
		}
		internal IModelA CurrentA
		{
			get
			{
				// Note the return type is "IModelA"; this represents the ModelA without giving view direct access to features of A.
				return _a;
			}
			set
			{
				// By design, IModelA always holds a ModelA (or null), so this cast always succeeds.
				_a = (ModelA)value;
			}
		}
		internal void SetCurrentModelA(IModelA desiredA)
		{
			// By design, IModelA always holds a ModelA (or null), so this cast always succeeds.
			_a = (ModelA)desiredA;
		}
		internal void Store()
		{
			// Called by V1 to store user input back to model(s).
			if (_a != null)
				_a.TextA = _owner.Text1;
		}
	}
	// ---------- "Blind" Model Interfaces ----------
	// This has NO methods. It is used to pass around a "ModelA" WITHOUT exposing its features or class.
	// It is all that a "View" is allowed to know; must be passed to a VM to act on it.
	internal interface IModelA
	{
	}
	// ---------- Models ----------
	internal class ModelA : IModelA
	{
		internal string TextA;
	}
