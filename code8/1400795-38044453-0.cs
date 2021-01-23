	using System;
	using System.Linq;
	using System.Drawing;
	using System.Windows.Forms;
	using System.Collections.Generic;
	using System.Reflection;
	
	public class TicTacToe : Panel
	{
		public TicTacToe()
		{
			// Properties.
			this.Size = new Size(281, 360);
			this.BackColor = Color.White;
			// This part adds the score and player turn labels.
			this.Controls.AddRange(new Control[] { Wins, Losses, Turn });
			// To generate random places for the computer.
			Random opponentPlay = new Random();
			
			// Computer playing code.
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
			
			// Load game.
			for (int x = 0; x < board.Count; x++)
			{
				for (int y = 0; y < board.Count; y++)
				{
					board[x][y].Location = new Point(4 + (x * 92), 4 + (y * 92));
                    // Add player click event.
					board[x][y].Click += delegate (object sender, EventArgs e)
					{
						if (turn == 1)
						{
							if (((Button)sender).Text.Length == 0)
							{
								((Button)sender).Text = "0";
								CheckGame();
							}
						}
					};
			        // Add buttons to game.
					this.Controls.Add(board[x][y]);
				}
			}
		}
		
		// This checks for wins, losses, draws, and changes the turn.
		public void CheckGame()
		{
			List<List<bool>> playerCount = new List<List<bool>>() { new List<bool> { false, false, false }, new List<bool> { false, false, false }, new List<bool> { false, false, false } } ;
			List<List<bool>> opponentCount = new List<List<bool>>() { new List<bool> { false, false, false }, new List<bool> { false, false, false }, new List<bool> { false, false, false } } ;
			
			for (int x = 0; x < board.Count; x++)
			{
				for (int y = 0; y < board.Count; y++)
				{
					// These check the board.
					if (board[x][y].Text == "0")
						playerCount[x][y] = true;
					
					if (board[x][y].Text == "X")
						opponentCount[x][y] = true;
					
					if (board[x][y].Text.Length == 1)
						draw[x][y] = true;
				}
			}
			
			if (playerCount[0][0] == true && playerCount[1][0] == true && playerCount[2][0] == true)
				EndGame(true);
			else if (playerCount[0][1] == true && playerCount[1][1] == true && playerCount[2][1] == true)
				EndGame(true);
			else if (playerCount[0][2] == true && playerCount[1][2] == true && playerCount[2][2] == true)
				EndGame(true);
			else if (playerCount[0][0] == true && playerCount[0][1] == true && playerCount[0][2] == true)
				EndGame(true);
			else if (playerCount[1][0] == true && playerCount[1][1] == true && playerCount[1][2] == true)
				EndGame(true);
			else if (playerCount[2][0] == true && playerCount[2][1] == true && playerCount[2][2] == true)
				EndGame(true);
			else if (playerCount[0][0] == true && playerCount[1][1] == true && playerCount[2][2] == true)
				EndGame(true);
			else if (playerCount[0][2] == true && playerCount[1][1] == true && playerCount[2][0] == true)
				EndGame(true);
			
			if (opponentCount[0][0] == true && opponentCount[1][0] == true && opponentCount[2][0] == true)
				EndGame(false);
			else if (opponentCount[0][1] == true && opponentCount[1][1] == true && opponentCount[2][1] == true)
				EndGame(false);
			else if (opponentCount[0][2] == true && opponentCount[1][2] == true && opponentCount[2][2] == true)
				EndGame(false);
			else if (opponentCount[0][0] == true && opponentCount[0][1] == true && opponentCount[0][2] == true)
				EndGame(false);
			else if (opponentCount[1][0] == true && opponentCount[1][1] == true && opponentCount[1][2] == true)
				EndGame(false);
			else if (opponentCount[2][0] == true && opponentCount[2][1] == true && opponentCount[2][2] == true)
				EndGame(false);
			else if (opponentCount[0][0] == true && opponentCount[1][1] == true && opponentCount[2][2] == true)
				EndGame(false);
			else if (opponentCount[0][2] == true && opponentCount[1][1] == true && opponentCount[2][0] == true)
				EndGame(false);
			
			if (draw[0].SequenceEqual(new List<bool> { true, true, true } ) && draw[1].SequenceEqual(new List<bool> { true, true, true } ) && draw[2].SequenceEqual(new List<bool> { true, true, true } ))
			{
				running = false;
			
				MessageBox.Show("Draw! No one won...", "Tic Tac Toe");
				
				for (int x = 0; x < board.Count; x++)
				{
					for (int y = 0; y < board.Count; y++)
					{
						board[x][y].Text = "";
						draw[x][y] = false;
					}
				}
			
				turn = 2;
				running = true;
			}
			
			if (running)
			{
				if (turn == 2)
				{
					turn = 1;
					Turn.Text = "Your Turn";
				}
				else
				{
					turn = 2;
					Turn.Text = "Opponents Turn";
					opponentDelay.Start();
				}
			}
		}
		
		// End game code.
		public void EndGame(bool win)
		{
			running = false;
			
			if (win)
			{
				MessageBox.Show("You Win!", "Tic Tac Toe");
				wins++;
				Wins.Text = "Wins: " + wins.ToString();
			}
			else
			{
				MessageBox.Show("Sorry but you lost, better luck next time...", "Tic Tac Toe");
				losses++;
				Losses.Text = "Losses: " + losses.ToString();
			}
			
			// Reset game.
			for (int x = 0; x < board.Count; x++)
			{
				for (int y = 0; y < board.Count; y++)
				{
					board[x][y].Text = "";
					draw[x][y] = false;
				}
			}
			
			// This sets the turn to the computer because when the game starts again it changes to the other player's turn for some reason.
			turn = 2;
			running = true;
		}
		
		public int turn = 1;
		public bool running = true;
		public int wins = 0;
		public int losses = 0;
		public Label Wins = new Label() { Text = "Wins: 0", Location = new Point(30, 310), AutoSize = false, Size = new Size(54, 17)  };
		public Label Losses = new Label() { Text = "Losses: 0", Location = new Point(95, 310), AutoSize = false, Size = new Size(66, 17)  };
		public Label Turn = new Label() { Text = "Your Turn", Location = new Point(175, 310) };
		public Timer opponentDelay = new Timer() { Interval = 500 };
		public List<List<bool>> draw = new List<List<bool>>() { new List<bool> { false, false, false }, new List<bool> { false, false, false }, new List<bool> { false, false, false } } ;
		// Instead of having buttons and ints, just read the button text.
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
