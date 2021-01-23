    public partial class Form1 : Form
	{
		const char leftParenChar = '(';
		const char rightParenChar = ')';
		public Form1()
		{
			InitializeComponent();
		}
		public void checkParensButton_Click(object sender, EventArgs e)
		{
			checkBalancedParens(mathEquation.Text);
		}
		bool checkBalancedParens(string expression)
		{
			var leftParensIndexes = new Stack<int>(expression.Length);
			var rightParensIndexes = new Stack<int>(expression.Length);
			var isError = false;
			for (int i = 0; i < expression.Length; i++)//Check for unbalanced Parentheses
			{
				char p = expression[i];
				if (p == leftParenChar)//if p finds left parens
				{
					leftParensIndexes.Push(i);//push to top of stack
				}
				else if (p == rightParenChar)//if p finds right parens
				{
					rightParensIndexes.Push(i);
					//keep a record if there is an error, but don't stop yet.
					if (leftParensIndexes.Count == 0)
					{
						isError = true;
					}
					else
					{
						//eliminate the matching pair if it exists
						rightParensIndexes.Pop();
						leftParensIndexes.Pop();
					}
					
				}
			}
			if (leftParensIndexes.Count > 0)//if stack has more than 0 items
			{
				isError = true;
			}
			HighlightOffenders(rightParensIndexes.Concat(leftParensIndexes));
			return !isError;
		}
		private void HighlightOffenders(IEnumerable<int> listOfIndexes)
		{
			var text = mathEquation.Text;
			mathEquation.Clear();
			int lastIndex = 0; //store the last index you finished at (for string math)
			int count = 0; //the number of items that we've added (also for string math)
			foreach (var index in listOfIndexes.Reverse())
			{
				
				mathEquation.AppendText(text.Substring(lastIndex, index - lastIndex - count));
				mathEquation.SelectionFont = new Font(mathEquation.Font, FontStyle.Bold);
				mathEquation.AppendText(text.Substring(index,1));
				mathEquation.SelectionFont = new Font(mathEquation.Font, FontStyle.Regular);
				lastIndex = index;
				count++;
			}
			mathEquation.AppendText(text.Substring(lastIndex + count-1, text.Length - lastIndex - count + 1));
		}
	}
