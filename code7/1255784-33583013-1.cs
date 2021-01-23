    using System;
    using System.Windows.Forms;
    using System.Linq;
    
    namespace Sample
    {
    	public partial class MainForm : Form
    	{
    		// stores how many clicks you have done
    		int counter = 0;
    		
    		public MainForm()
    		{
    			InitializeComponent();
    		}
    		
    		void Button1Click(object sender, EventArgs e)
    		{
    			// split the first textbox using a comma
    			var words = textBox1.Text.Split(',');
    			
    			if (counter < words.Count())
    			{
    				// increase the counter
    				counter++;
    				
    				// take n words, where n = counter
    				textBox2.Text = string.Join(",", words.Take(counter));
    				
    				// skip n words, then take the rest (n = counter)
    				textBox3.Text = string.Join(",", words.Skip(counter).Take(words.Count() - counter));
    			}
    		}
    	}
    }
