	using System;
	using System.Linq;
	using System.Drawing;
	using System.Windows.Forms;
	using System.Collections.Generic;
	
	public class TicTacToe : Panel
	{
		public TicTacToe()
		{
			this.Size = new Size(281, 360);
			this.BackColor = Color.White;
			this.Controls.AddRange(new Control[] { wins, losses, turn });
			Random opponentPlay = new Random();
			
			opponentDelay.Tick += delegate
			{
				opponentDelay.Interval = 20;
				Point opponentPos = new Point(opponentPlay.Next(0, 3), opponentPlay.Next(0, 3));
				if (board[opponentPos.X][opponentPos.Y].Text.Length == 0)
				{
					board[opponentPos.X][opponentPos.Y].Text = "X";
					opponentDelay.Interval = 500;
					opponentDelay.Stop();
					CheckGame();
				}
			};
			
			for (int x = 0; x < board.Count; x++)
			{
				for (int y = 0; y < board.Count; y++)
				{
					board[x][y].Location = new Point(4 + (x * 92), 4 + (y * 92));
					board[x][y].Click += delegate (object sender, EventArgs e)
					{
						if (turn.Name == "1")
						{
							if (((Button)sender).Text.Length == 0)
							{
								((Button)sender).Text = "0";
								CheckGame();
							}
						}
					};
					this.Controls.Add(board[x][y]);
				}
			}
		}
		
		public void CheckGame()
		{
			// Check if player won.
			if (board[0][0].Text == "0" && board[1][0].Text == "0" && board[2][0].Text == "0")
				EndGame(0);
			else if (board[0][1].Text == "0" && board[1][1].Text == "0" && board[2][1].Text == "0")
				EndGame(0);
			else if (board[0][2].Text == "0" && board[1][2].Text == "0" && board[2][2].Text == "0")
				EndGame(0);
			else if (board[0][0].Text == "0" && board[0][1].Text == "0" && board[0][2].Text == "0")
				EndGame(0);
			else if (board[1][0].Text == "0" && board[1][1].Text == "0" && board[1][2].Text == "0")
				EndGame(0);
			else if (board[2][0].Text == "0" && board[2][1].Text == "0" && board[2][2].Text == "0")
				EndGame(0);
			else if (board[0][0].Text == "0" && board[1][1].Text == "0" && board[2][2].Text == "0")
				EndGame(0);
			else if (board[0][2].Text == "0" && board[1][1].Text == "0" && board[2][0].Text == "0")
				EndGame(0);
			
			// Check if opponent won.
			if (board[0][0].Text == "X" && board[1][0].Text == "X" && board[2][0].Text == "X")
				EndGame(1);
			else if (board[0][1].Text == "X" && board[1][1].Text == "X" && board[2][1].Text == "X")
				EndGame(1);
			else if (board[0][2].Text == "X" && board[1][2].Text == "X" && board[2][2].Text == "X")
				EndGame(1);
			else if (board[0][0].Text == "X" && board[0][1].Text == "X" && board[0][2].Text == "X")
				EndGame(1);
			else if (board[1][0].Text == "X" && board[1][1].Text == "X" && board[1][2].Text == "X")
				EndGame(1);
			else if (board[2][0].Text == "X" && board[2][1].Text == "X" && board[2][2].Text == "X")
				EndGame(1);
			else if (board[0][0].Text == "X" && board[1][1].Text == "X" && board[2][2].Text == "X")
				EndGame(1);
			else if (board[0][2].Text == "X" && board[1][1].Text == "X" && board[2][0].Text == "X")
				EndGame(1);
			
			// Check if nobody won.
			if (board[0][0].Text != "" && board[0][1].Text != "" && board[0][2].Text != "" && board[1][0].Text != "" && board[1][1].Text != "" && board[1][2].Text != "" && board[2][0].Text != "" && board[2][1].Text != "" && board[2][2].Text != "")
				EndGame(2);
			
			if (running)
			{
				if (turn.Name == "2")
				{
					turn.Name = "1";
					turn.Text = "Your turn";
				}
				else
				{
					turn.Name = "2";
					turn.Text = "Opponents turn";
					opponentDelay.Start();
				}
			}
		}
		
		public void EndGame(int win)
		{
			running = false;
			
			if (win == 0)
			{
				MessageBox.Show("You Win!", "Tic Tac Toe");
				wins.Name = (Convert.ToInt32(wins.Name) + 1).ToString();
				wins.Text = "Wins: " + wins.Name;
			}
			else if (win == 1)
			{
				MessageBox.Show("Sorry but you lost, better luck next time...", "Tic Tac Toe");
				losses.Name = (Convert.ToInt32(losses.Name) + 1).ToString();
				losses.Text = "Losses: " + losses.Name;
			}
			else
			{
				MessageBox.Show("Draw! No one won...", "Tic Tac Toe");
			}
			
			for (int x = 0; x < board.Count; x++)
			{
				for (int y = 0; y < board.Count; y++)
				{
					board[x][y].Text = "";
				}
			}
			
			turn.Name = "2";
			running = true;
		}
		
		public bool running = true;
		public Label wins = new Label() { Text = "Wins: 0", Name = "0", Location = new Point(30, 310), AutoSize = false, Size = new Size(54, 17)  };
		public Label losses = new Label() { Text = "Losses: 0", Name = "0", Location = new Point(95, 310), AutoSize = false, Size = new Size(66, 17)  };
		public Label turn = new Label() { Text = "Your turn", Name = "1", Location = new Point(175, 310) };
		public Timer opponentDelay = new Timer() { Interval = 500 };
		public List<List<Button>> board = new List<List<Button>>
		{
			new List<Button>
			{
				new Button() { Text = "", Font = new Font(SystemFonts.DefaultFont.Name, 26f, FontStyle.Bold), UseVisualStyleBackColor = true, TabStop = false, Size = new Size(90, 90) },
				new Button() { Text = "", Font = new Font(SystemFonts.DefaultFont.Name, 26f, FontStyle.Bold), UseVisualStyleBackColor = true, TabStop = false, Size = new Size(90, 90) },
				new Button() { Text = "", Font = new Font(SystemFonts.DefaultFont.Name, 26f, FontStyle.Bold), UseVisualStyleBackColor = true, TabStop = false, Size = new Size(90, 90) }
			},
			new List<Button>
			{
				new Button() { Text = "", Font = new Font(SystemFonts.DefaultFont.Name, 26f, FontStyle.Bold), UseVisualStyleBackColor = true, TabStop = false, Size = new Size(90, 90) },
				new Button() { Text = "", Font = new Font(SystemFonts.DefaultFont.Name, 26f, FontStyle.Bold), UseVisualStyleBackColor = true, TabStop = false, Size = new Size(90, 90) },
				new Button() { Text = "", Font = new Font(SystemFonts.DefaultFont.Name, 26f, FontStyle.Bold), UseVisualStyleBackColor = true, TabStop = false, Size = new Size(90, 90) }
			},
			new List<Button>
			{
				new Button() { Text = "", Font = new Font(SystemFonts.DefaultFont.Name, 26f, FontStyle.Bold), UseVisualStyleBackColor = true, TabStop = false, Size = new Size(90, 90) },
				new Button() { Text = "", Font = new Font(SystemFonts.DefaultFont.Name, 26f, FontStyle.Bold), UseVisualStyleBackColor = true, TabStop = false, Size = new Size(90, 90) },
				new Button() { Text = "", Font = new Font(SystemFonts.DefaultFont.Name, 26f, FontStyle.Bold), UseVisualStyleBackColor = true, TabStop = false, Size = new Size(90, 90) }
			}
		};
	}
