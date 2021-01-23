    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Threading;
    
    
    namespace viseNitniRad
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                
            }
            private int firstNum = 0;
            private int secondNum = 0;
            public Thread firstThread;
            public Thread secondThread;
    
            public  void WriteInLog(string message)
            {
                if (this.textBox3.InvokeRequired)
                {
                    ThreadSum ts = new ThreadSum(WriteInLog);
                    this.Invoke(ts, new object[] { message });
                    
                }
                else
                {
                    this.textBox3.Text += message + Environment.NewLine;
                }
            }
            
            private void CheckInput()
            {
                int pom = 0;
                firstNum = int.Parse(textBox1.Text);
                secondNum = int.Parse(textBox2.Text);
                if (firstNum > secondNum) {
                    pom = secondNum;
                    secondNum = firstNum;
                    firstNum = pom; }
    
                WriteInLog("Prvi broj: " + firstNum.ToString());
                WriteInLog("Drugi broj: " + secondNum.ToString());
            }
            
           
            private void button1_Click(object sender, EventArgs e)
            {
                CheckInput();
           
        }
            public delegate void ThreadSum(string message);
            public delegate void ThreadUmn();
            public void Threadsumm()
            {
                int suma = 0;
                for (int i = firstNum; i < secondNum; i++)
                    suma += i;
                WriteInLog("Suma= " + suma.ToString() + " kraj: " + DateTime.Now.ToString());
               
            }
            public  void ThreadUmno()
            {
                int umnozak = 1;
                for (int i = firstNum; i < secondNum; i++)
                    umnozak*= i;
                WriteInLog("Umnozak= " + umnozak.ToString() + " kraj: " + DateTime.Now.ToString());
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                WriteInLog("Pocetak svih izracuna u: " + DateTime.Now.ToString());
    
                firstThread = new Thread(new ThreadStart(Threadsumm));
              secondThread = new Thread(new ThreadStart(ThreadUmno));
              
                
                firstThread.Start();
            
                secondThread.Start();
             
              
            }
        }
    }
