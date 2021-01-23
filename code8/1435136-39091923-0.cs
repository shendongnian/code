        public partial class Form1 : Form
        {
            private bool SkipWarning = false;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                if(!SkipWarning)
                {
                    DialogResult dialogo = MessageBox.Show("¿Desea cerrar la aplicación?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                    if (dialogo == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
    
            private void aceptar_MouseClick(object sender, MouseEventArgs e)
        {
           if(Contador == 2)
            {
                SkipWarning = true;
                DialogoCerrar();
                Close();
            } 
           if (usuario.Text == ("Demo") && (contraseña.Text == ("ABC123")))
            {
                Contador = 0;
                DialogResult dialogo = MessageBox.Show("Ingreso exitoso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dialogo = MessageBox.Show("Datos incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Contador++;
            }                   
          }
        }
