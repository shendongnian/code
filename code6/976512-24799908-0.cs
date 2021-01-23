    private void testButton_Click(object sender, EventArgs e)
    {
        GeneratedClass gc = new GeneratedClass();
        gc.CreatePackage(this.testTxt.Text);
    }
    public class GeneratedClass
    {
          public void CreatePackage(string name) { // DoStuff! }
    }
    
