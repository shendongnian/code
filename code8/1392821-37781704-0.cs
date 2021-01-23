      using System;
      using System.Collections.Generic;
     using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        static class Program
     {
        /// <summary>
           /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 NewForm = new Form1();
            Application.Run(NewForm); // program stops executing here and goes to draw your form
    
             //program resumes execution here after you close your form.
            string[][] list = new string[10][];
            list[0] = new[] { "abandon", "leave" };
            list[1] = new[] { "abbreviate", "shorten" };
            list[2] = new[] { "option", "choice" };
            list[3] = new[] { "Inferior", "lesser", "second-class", "second-fiddle", "minor", "subservient", "lowly",         "humble", "menial" };
            list[4] = new[] { "Nauseous", "sick", "nauseated", "queasy", "bilious" };
            list[5] = new[] { "Uniform", "constant", "consistent", "steady", "invariable", "unvarying", "unfluctuating",     "unvaried", "unchanging", "unwavering", "undeviating", "stable", "static", "sustained", "regular", "fixed", "even", "equal", "equable", "monotonous" };
            list[6] = new[] { "Incision", "cut", "opening", "slit" };
            list[7] = new[] { "perplexed", "puzzled" };
            list[8] = new[] { "polarity", "difference", "separation", "opposition", "contradiction" };
            list[9] = new[] { "Abundance", "profusion", "plenty", "wealth", "copiousness" };
            for (int counter = 0; counter < 20; counter++) {
            NewForm.UpdateQuestion("Question Number");
           
            }
    
        }
    }
  
