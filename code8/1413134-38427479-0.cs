    public partial class Form1 : Form
    {
        double totalOne = 0.0;
        string startingState;
        string calculation;
        Func<double, double, double> operation = null;
        public Form1()
        {
            InitializeComponent();
            btnClear.Click += (s, e) =>
            {
                startingState = "";
                totalOne = 0.0;
                calculation = "";
                operation = null;
                textDisplay.Clear();
            };
            var numerals = new[]
            {
                btnZero, btnOne, btnTwo, btnThree, btnFour, btnFive, btnSix, btnSeven, btnEight, btnNine, btnDecimal,
            };
            foreach (var numeral in numerals)
            {
                var button = numeral;
                button.Click += (s, e) =>
                {
                    startingState += button.Text;
                    calculation += button.Text;
                    textDisplay.Text = startingState + "\r\n" + calculation;
                };
            }
            var ops = new Dictionary<Button, Func<double, double, double>>()
            {
                { btnPlus, (x, y) => x + y },
                { btnMinus, (x, y) => x - y },
                { btnMultiply, (x, y) => x * y },
                { btnDivide, (x, y) => x / y },
            };
            foreach (var x in ops)
            {
                var button = x.Key;
                var op = x.Value;
                button.Click += (s, e) =>
                {
                    var totalTwo = double.Parse(startingState);
                    totalOne = operation == null ? totalTwo : operation(totalOne, totalTwo);
                    startingState = "";
                    calculation += button.Text;
                    textDisplay.Text = "" + "\r\n" + calculation;
                    operation = op;
                };
            }
            btnEqual.Click += (s, e) =>
            {
                if (operation != null)
                {
                    var totalTwo = double.Parse(startingState);
                    totalOne = operation(totalOne, totalTwo);
                    textDisplay.Text = String.Join(Environment.NewLine, new[] { "", calculation, "_______________", totalOne.ToString() });
                    startingState = totalOne.ToString();
                    operation = null;
                }
            };
        }
    }
