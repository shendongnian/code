    using System;
    using System.Windows.Forms;
    
    namespace Tests
    {
    	public class Conta
    	{
    		public int Numero { get; set; }
    		public double Saldo { get; set; }
    		public Cliente Titular { get; set; }
    		public override string ToString()
    		{
    			return "titular: " + this.Titular.Nome;
    		}
    	}
    	public class Cliente
    	{
    		public string Nome { get; set; }
    		public string Rg { get; set; }
    		public Cliente(string nome)
    		{
    			this.Nome = nome;
    		}
    		public override string ToString()
    		{
    			return "ToString do Cliente: " + this.Nome;
    		}
    	}
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var form = new Form { Padding = new Padding(16) };
    			var comboBox = new ComboBox { Dock = DockStyle.Top, Parent = form };
    			comboBox.DisplayMember = "Titular";
    			comboBox.Items.AddRange( new []
    			{
    				new Conta { Titular = new Cliente("Victor") },
    				new Conta { Titular = new Cliente("Mauricio") },
    				new Conta { Titular = new Cliente("csni") },
    			});
    			Application.Run(form);
    		}
    	}
    }
