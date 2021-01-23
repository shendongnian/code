    namespace Test
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            List<int> numbers = new List<int>();
    
            private void btnNumbers_Click(object sender, EventArgs e)
            {
                int x;
                if (!Int32.TryParse(txtNumbers.Text, out x)) return;
                numbers.Add(x);
                SmallestAndLargest(numbers.ToArray());
            }
            private void SmallestAndLargest(int[] numbers)
            {
                Array.Sort(numbers);
                int x;
                lblSorted.Text = String.Empty;
                for (x = 0; x < numbers.Length; ++x)                        
                    lblSorted.Text += String.Format("  {0} ", numbers[x]);
                lblSmallest.Text = String.Format("Smallest Number Entered: {0} ", numbers[0]);
                lblLargest.Text = String.Format("Largest Number Entered: {0} ", numbers[numbers.Length - 1]);
            }
        }
    }
