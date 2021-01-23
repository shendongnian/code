    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Tests
    {
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			Application.Run(new ScoreBoardForm { WindowState = FormWindowState.Maximized });
    		}
    	}
    
    	class ScoreBoardForm : Form
    	{
    		protected override void OnLoad(EventArgs e)
    		{
    			base.OnLoad(e);
    
    			players = new List<Player>();
    			for (int i = 0; i < 1000; i++)
    				players.Add(new Player { ID = i + 1, Name = "P" + (i + 1), Total = random.Next(1000) });
    			games = new List<Game>();
    			for (int i = 0; i < 10; i++)
    				games.Add(new Game { ID = i + 1, Name = "G" + (i + 1) });
    
    			InitScoreBoard();
    			UpdateScoreBoard();
    
    			updateTimer = new Timer { Interval = 100 };
    			updateTimer.Tick += (_sender, _e) => UpdateScoreBoard();
    			updateTimer.Start();
    		}
    
    		DataGridView scoreBoardTable;
    		Timer updateTimer;
    		List<Player> players;
    		List<Game> games;
    		Random random = new Random();
    		class Player
    		{
    			public int ID;
    			public string Name;
    			public int Total;
    		}
    		class Game
    		{
    			public int ID;
    			public string Name;
    		}
    		private int GetScore(Player player, Game game)
    		{
    			return random.Next(10000);
    		}
    		void InitScoreBoard()
    		{
    			scoreBoardTable = new DataGridView { Dock = DockStyle.Fill, Parent = this };
    			scoreBoardTable.Font = new Font("Microsoft Sans Serif", 25, FontStyle.Bold);
    			scoreBoardTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    			scoreBoardTable.MultiSelect = false;
    			scoreBoardTable.CellBorderStyle = DataGridViewCellBorderStyle.None;
    			scoreBoardTable.BackgroundColor = Color.Honeydew;
    			scoreBoardTable.ForeColor = Color.Black;
    			scoreBoardTable.AllowUserToAddRows = scoreBoardTable.AllowUserToDeleteRows = scoreBoardTable.AllowUserToOrderColumns = scoreBoardTable.AllowUserToResizeRows = false;
    			scoreBoardTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    			scoreBoardTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
    			scoreBoardTable.RowHeadersVisible = false;
    			scoreBoardTable.EnableHeadersVisualStyles = false;
    			var style = scoreBoardTable.DefaultCellStyle;
    			style.SelectionForeColor = style.SelectionBackColor = Color.Empty;
    			style = scoreBoardTable.ColumnHeadersDefaultCellStyle;
    			style.SelectionForeColor = style.SelectionBackColor = Color.Empty;
    			style.BackColor = Color.Navy;
    			style.ForeColor = Color.White;
    			style = scoreBoardTable.RowHeadersDefaultCellStyle;
    			style.SelectionForeColor = style.SelectionBackColor = Color.Empty;
    			style = scoreBoardTable.RowsDefaultCellStyle;
    			style.SelectionForeColor = style.ForeColor = Color.Black;
    			style.SelectionBackColor = style.BackColor = Color.Yellow;
    			style = scoreBoardTable.AlternatingRowsDefaultCellStyle;
    			style.SelectionForeColor = style.ForeColor = Color.Black;
    			style.SelectionBackColor = style.BackColor = Color.LightGreen;
    			scoreBoardTable.CellFormatting += OnScoreBoardCellFormatting;
    		}
    		private void UpdateScoreBoard()
    		{
    			scoreBoardTable.ColumnCount = 3 + games.Count;
    			for (int c = 0; c < scoreBoardTable.ColumnCount; c++)
    			{
    				var col = scoreBoardTable.Columns[c];
    				if (c == 0)
    				{
    					col.Name = "Rank";
    					col.HeaderText = "";
    					col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
    					col.Width = 48;
    				}
    				else if (c == 1)
    				{
    					col.Name = "Player";
    					col.HeaderText = "Player";
    					col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
    				}
    				else if (c == scoreBoardTable.ColumnCount - 1)
    				{
    					col.Name = "Totals";
    					col.HeaderText = "Totals";
    					col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    					//col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    				}
    				else
    				{
    					var game = games[c - 2];
    					col.Name = "Game_" + game.ID;
    					col.HeaderText = game.Name;
    					col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    					//col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
    				}
    			}
    			scoreBoardTable.RowCount = players.Count;
    			scoreBoardTable.AutoResizeColumnHeadersHeight();
    			scoreBoardTable.Invalidate();
    		}
    		private void OnScoreBoardCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    		{
    			var player = players[e.RowIndex];
    			int col = e.ColumnIndex;
    			if (col == 0)
    				e.Value = "";
    			else if (col == 1)
    				e.Value = player.Name;
    			else if (col == scoreBoardTable.ColumnCount - 1)
    				e.Value = player.Total.ToString();
    			else
    			{
    				var game = games[col - 2];
    				e.Value = GetScore(player, game).ToString();
    			}
    			e.FormattingApplied = true;
    		}
    	}
    }
