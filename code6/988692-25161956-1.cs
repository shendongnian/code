        public partial class Form1 : Form
            {
                public double livingSpaceCost;
                public double builtinGarageCost;
                public double attachedGarageCost;
                public double deckCost;
                public double openPorchCost;
                public double enclosedPorchCost;
                public double additionalFeaturesCost;
                public Form1()
                {
                    InitializeComponent();
                    livingSpaceCost = 0;
                    builtinGarageCost = 0;
                    attachedGarageCost = 0;
                    deckCost = 0;
                    openPorchCost = 0;
                    enclosedPorchCost = 0;
                    additionalFeaturesCost = 0;
                }
                void calctotalrc()
                {
                    double total;
                    total = livingSpaceCost + builtinGarageCost + attachedGarageCost + deckCost + openPorchCost + enclosedPorchCost + additionalFeaturesCost;
                    txtTotalReplacementCost.Text = total.ToString();
                }
    
    public void txtBuiltInGarage_TextChanged(object sender, EventArgs e)
        {
            int outputValue = 0;
            bool isNumber = false;
    
            isNumber = int.TryParse(txtBuiltInGarage.Text, out outputValue);
    
            if (!isNumber)
            {
                txtBuiltInGarage.Text = "";
                txtBuiltInGarageCost.Text = "";
            }
            else
            {
                int builtinGarageSQ;
                int builtinGarageCostPerSF = 100;
    
                builtinGarageSQ = int.Parse(txtBuiltInGarage.Text.ToString());
                builtinGarageCost = builtinGarageSQ * builtinGarageCostPerSF;
                txtBuiltInGarageCost.Text = builtinGarageCost.ToString();
            }
            calctotalrc();
        }
     }
