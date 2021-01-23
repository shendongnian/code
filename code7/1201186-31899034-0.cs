    public class MyForm : Form
    {
        private IList<Car> _cars;
        ...
        public void myButton_OnClick(object sender, EventArgs e)
        {
            _cars.Add(new Car());
        }
        ...
    }
