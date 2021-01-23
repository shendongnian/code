    public class SomethingInThePresentationLayer
    {
        public void SomeMethod()
        {
            var businessObject = new SomethingInTheBusinessLayer();
            businessObject.Validate();
        }
    }
    public class SomethingInTheBusinessLayer
    {
        public void Validate()
        {
            pageElement.Text = "This is the text.";
        }
    }
