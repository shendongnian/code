    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int x = comboBox1.SelectedIndex;
            Factory[] objFactories = new Factory[1];
            switch (x)
            {
                case 0:
                    objFactories[0] = new Figura1();
                    foreach (Factory ob in objFactories)
                    {
                        FIGURAS objProduct = ob.GetFig();
                        objProduct.Mensaje();
                    }
                    break;
                case 1:
                    objFactories[0] = new Figura2();
                    foreach (Factory ob in objFactories)
                    {
                        FIGURAS objProduct = ob.GetFig();
                        objProduct.Mensaje();
                    }
                    break;
                case 2:
                    objFactories[0] = new Figura3();
                    foreach (Factory ob in objFactories)
                    {
                        FIGURAS objProduct = ob.GetFig();
                        objProduct.Mensaje();
                    }
                    break;
                default:
                    {
                        MessageBox.Show("***");
                        break;
                    }
            }
        }
        public abstract class Factory
        {
            public abstract FIGURAS GetFig();
        }
        public class Figura1 : Factory
        {
            public override FIGURAS GetFig()
            {
                return new Fig1();
            }
        }
        public class Figura2 : Factory
        {
            public override FIGURAS GetFig()
            {
                return new Fig2();
            }
        }
        public class Figura3 : Factory
        {
            public override FIGURAS GetFig()
            {
                return new Fig3();
            }
        }
        public interface FIGURAS
        {
            void Mensaje();
        }
        public class Fig1 : FIGURAS
        {
            public void Mensaje()
            {
                MessageBox.Show("FIGURA 1: CUADRADO");
            }
        }
        public class Fig2 : FIGURAS
        {
            public void Mensaje()
            {
                MessageBox.Show("FIGURA 2: RECTANGULO");
            }
        }
        public class Fig3 : FIGURAS
        {
            public void Mensaje()
            {
                MessageBox.Show("FIGURA 3: TRIANGULO");
            }
        }
    }
}
