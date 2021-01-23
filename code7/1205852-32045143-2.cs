    // Add following namespaces
    using System.Windows.Forms;
    using System.Drawing;
    
    // Retrieve the working rectangle from the Screen class using the PrimaryScreen and the 
    // WorkingArea properties.
	Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
	
	// Set the size of the form slightly less than size of working rectangle. 
	this.Size = new Size(workingRectangle.Width, workingRectangle.Height);
