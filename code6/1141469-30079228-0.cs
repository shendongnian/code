        public List<int> Numbers { get; set; }
        private void btnNumbers_Click(object sender, EventArgs e)
        {
            var currentVal = 0;
            if (Int32.TryParse(txtNumbers.Text, out currentVal))
                Numbers.Add(currentVal);
            SmallestAndLargest();
        }
        private void SmallestAndLargest()
        {
            Numbers.Sort(); //Sorts
            var max = 0;
            foreach(var x in Numbers)
            {
                lblSorted.Text += String.Format("  {0} ", x);
                max = x; //As List is sorted the current x is always the maximum value
            }            
                
            lblSmallest.Text = String.Format("Smallest Number Entered: {0} ", Numbers.ElementAt(0));
            lblLargest.Text = String.Format("Largest Number Entered: {0} ", max);
        }
