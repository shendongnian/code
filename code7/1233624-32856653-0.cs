    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Practice_randomizing
    {
    	public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    		}
    		private void button1_Click(object sender, EventArgs e)
    		{
    			Random Rand = new Random();
    			int Random = Rand.Next(6);
    
    			int player1;
    			player1 = 0;
    			int player2;
    			player2 = 0;
    
    			if
    			(Random == 0)
    			{
    				pictureBox1.Image = Properties.Resources.dice_11;
    				label1.Text = "You got a 1!";
    				pictureBox1.Visible = true;
    			}
    
    			else if(Random == 1)
    			{
    				pictureBox1.Image = Properties.Resources.dice_21;
    				label1.Text = "You got a 2!";
    				pictureBox1.Visible = true;
    			}
    			else if(Random == 2)
    			{
    				pictureBox1.Image = Properties.Resources.dice_31;
    				label1.Text = "You got a 3!";
    				pictureBox1.Visible = true;
    			}
    			else if(Random == 3)
    			{
    				pictureBox1.Image = Properties.Resources.dice_41;
    				label1.Text = "You got a 4!";
    				pictureBox1.Visible = true;
    			}
    			else if(Random == 4)
    			{
    				pictureBox1.Image = Properties.Resources.dice_51;
    				label1.Text = "You got a 5!";
    				pictureBox1.Visible = true;
    			}
    			else
    			{
    				pictureBox1.Image = Properties.Resources.dice_61;
    				label1.Text = "You got a 6!";
    				pictureBox1.Visible = true;
    
    				{
    					int dice2 = Rand.Next(6);
    					if(dice2 == 0)
    					{
    						pictureBox2.Image = Properties.Resources.dice_11;
    						label5.Text = "You got a 1!";
    						pictureBox2.Visible = true;
    					}
    					else if(dice2 == 1)
    					{
    						pictureBox2.Image = Properties.Resources.dice_21;
    						label5.Text = "You got a 2!";
    						pictureBox2.Visible = true;
    					}
    					else if(dice2 == 2)
    					{
    						pictureBox2.Image = Properties.Resources.dice_31;
    						label5.Text = "You got a 3!";
    						pictureBox2.Visible = true;
    					}
    					else if(dice2 == 3)
    					{
    						pictureBox2.Image = Properties.Resources.dice_41;
    						label5.Text = "You got a 4!";
    						pictureBox2.Visible = true;
    					}
    					else if(dice2 == 4)
    					{
    						pictureBox2.Image = Properties.Resources.dice_51;
    						label5.Text = "You got a 5!";
    						pictureBox2.Visible = true;
    					}
    					else
    					{
    						pictureBox2.Image = Properties.Resources.dice_61;
    						label5.Text = "You got a 6!";
    						pictureBox2.Visible = true;
    
    						if(Random == 0 && dice2 == 0)
    							label4.Text = "Tie!";
    						if(Random == 0 && dice2 == 0)
    							label4.Text = "Tie!";
    
    						else if(Random == 1 && dice2 == 1)
    							label4.Text = "Tie!";
    						else if(Random == 2 && dice2 == 2)
    							label4.Text = "Tie!";
    						else if(Random == 3 && dice2 == 3)
    							label4.Text = "Tie!";
    						else if(Random == 4 && dice2 == 4)
    							label4.Text = "Tie!";
    						else if(Random == 5 && dice2 == 5)
    							label4.Text = "Tie!";
    						else if(Random == 1 && dice2 == 0)
    						{
    							label2.Text = "Win!";
    							player1++;
    							label4.Text = " " + player1;
    						}
    						else if(Random == 1 && dice2 == 2)
    							label3.Text = "win!";
    						else if(Random == 1 && dice2 == 3)
    							label3.Text = "win!";
    						else if(Random == 1 && dice2 == 4)
    							label3.Text = "win!";
    						else if(Random == 1 && dice2 == 5)
    						{
    							label2.Text = "win!";
    							player1++;
    							label6.Text = " " + player1;
    						}
    						else if(Random == 2 && dice2 == 0)
    							label2.Text = "Win!";
    						else if(Random == 2 && dice2 == 1)
    							label2.Text = "win!";
    						else if(Random == 2 && dice2 == 3)
    							label3.Text = "win!";
    						else if(Random == 2 && dice2 == 4)
    							label2.Text = "win!";
    						else if(Random == 2 && dice2 == 5)
    							label2.Text = "win!";
    						else if(Random == 3 && dice2 == 0)
    							label2.Text = "win!";
    						else if(Random == 3 && dice2 == 1)
    							label2.Text = "win!";
    						else if(Random == 3 && dice2 == 2)
    							label2.Text = "win!";
    						else if(Random == 3 && dice2 == 4)
    							label3.Text = "win!";
    						else if(Random == 3 && dice2 == 5)
    							label3.Text = "win!";
    						else if(Random == 4 && dice2 == 0)
    							label2.Text = "win!";
    						else if(Random == 4 && dice2 == 1)
    							label2.Text = "win!";
    						else if(Random == 4 && dice2 == 2)
    							label2.Text = "win!";
    						else if(Random == 4 && dice2 == 3)
    							label2.Text = "win!";
    						else if(Random == 4 && dice2 == 5)
    							label3.Text = "win!";
    						else if(Random == 5 && dice2 == 0)
    							label2.Text = "win!";
    						else if(Random == 5 && dice2 == 1)
    							label2.Text = "win!";
    						else if(Random == 5 && dice2 == 2)
    							label2.Text = "win!";
    						else if(Random == 5 && dice2 == 3)
    							label2.Text = "win!";
    						else if(Random == 5 && dice2 == 4)
    							label2.Text = "win!";
    
    						label2.Text = " ";
    						label3.Text = " ";
    						label4.Text = " ";
    					}
    				}
    			}
    		}
    	}
    }
