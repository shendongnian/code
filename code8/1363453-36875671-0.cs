    // At the top of the file
    using System.Drawing;
    //  ...
    // In your method:
    // Store associations with checkboxes and their colors
    // in a convenient array, making it easy to extend in
    // case additional colors need to be supported
    var checkBoxColors = new[] {
      new { CheckBox = checkBoxBlue, Color = Color.Blue },
      new { CheckBox = checkBoxBlack, Color = Color.Black }
      // Add more if needed
    };
    foreach(var check in checkBoxColors) {
      if (check.CheckBox.Checked) {
        // Rename `check.Color` to a shorter variable 
        var color = check.Color;
        labelOrigo.ForeColor = color;
        labelN.ForeColor = color;
        // ...and so on        
      }
    }
