	public class SomeClass
	{
		private readonly Form1 parent;
		public SomeClass(Form1 form)
		{
			this.parent = form;
		}
		public void DoStuff()
		{
			this.parent.UpdateCube()
		}
	}
	public partial class Form1
	{
		private SomeClass CreateChild()
		{
			return new SomeClass(this);
		}
	    public void UpdateCube()
	    {
	        if (BTL.BackColor != mapColor(c1.B.TR))
	        {
	            BTL.BackColor = mapColor(c1.B.TR);
	            System.Console.Write("Mapping");
	        }
	        //And so on
	    }
		// The rest of the class
	}
