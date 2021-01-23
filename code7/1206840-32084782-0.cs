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
    			for (int i = 0; i < 100; i++)
    				players.Add(new Player { ID = i + 1, Name = "P" + (i + 1), Total = random.Next(1000) });
    			games = new List<Game>();
    			for (int i = 0; i < 10; i++)
    				games.Add(new Game { ID = i + 1, Name = "G" + (i + 1) });
    
    			scoreBoardTable = new ScoreBoardTable { Dock = DockStyle.Fill, Parent = this };
    			scoreBoardTable.Bounds = this.DisplayRectangle;
    			UpdateScoreBoard();
    			scoreBoardTable.CellPaint += OnScoreBoardTableCellPaint;
    
    			updateTimer = new Timer { Interval = 100 };
    			updateTimer.Tick += (_sender, _e) => UpdateScoreBoard();
    			updateTimer.Start();
    		}
    		private void OnScoreBoardTableCellPaint(object sender, TableLayoutCellPaintEventArgs e)
    		{
    			int playerIndex = e.Row - 1, gameIndex = e.Column - 2;
    			if (playerIndex >= 0 && playerIndex < players.Count && gameIndex >= 0 && gameIndex < games.Count)
    			{
    				using (var br = new SolidBrush(GetBackColor(e.Row)))
    					e.Graphics.FillRectangle(br, e.CellBounds);
    				var score = GetScore(players[playerIndex], games[gameIndex]);
    				var sf = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
    				e.Graphics.DrawString(score.ToString(), defaultCellFont, Brushes.Black, e.CellBounds, sf);
    			}
    		}
    		private int GetScore(Player player, Game game)
    		{
    			return random.Next(10000);
    		}
    		class ScoreBoardTable : TableLayoutPanel
    		{
    			public ScoreBoardTable() { DoubleBuffered = AutoScroll = true; }
    		}
    		TableLayoutPanel scoreBoardTable;
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
    		private void UpdateScoreBoard()
    		{
    			scoreBoardTable.SuspendLayout();
    			GenerateTable(games.Count + 3, players.Count + 1);
    			GenerateHeaderCells();
    			// Custom cell paint is much faster, but requires a good data model.
    			// If you uncomment the following line, make sure to get rid of CellPaint. 
    			//GenerateScoreCells();
    			scoreBoardTable.ResumeLayout(true);
    		}
    		private void GenerateTable(int columnCount, int rowCount)
    		{
    			scoreBoardTable.Controls.Clear();
    			scoreBoardTable.ColumnStyles.Clear();
    			scoreBoardTable.RowStyles.Clear();
    			scoreBoardTable.ColumnCount = columnCount;
    			scoreBoardTable.RowCount = rowCount;
    
    			// Columns
    			// Ranking
    			scoreBoardTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
    			// Name 
    			scoreBoardTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
    			// Games
    			var percent = (columnCount - 3) / (float)columnCount;
    			for (int col = 2; col < columnCount - 1; col++)
    				scoreBoardTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
    			// Totals
    			scoreBoardTable.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
    
    			// Rows
    			// Header
    			scoreBoardTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
    			// Players
    			for (int row = 1; row < rowCount; row++)
    				scoreBoardTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
    		}
    		private void GenerateHeaderCells()
    		{
    			Color backColor = Color.DarkGray, foreColor;
    			int row, col;
    			// Header
    			row = 0;
    			foreColor = Color.White;
    			col = 0;
    			AddCell(row, col++, "rank", "", foreColor, backColor);
    			AddCell(row, col++, "playerName", "Player", foreColor, backColor);
    			foreach (var game in games)
    				AddCell(row, col++, "gameName" + game.ID, game.Name, foreColor, backColor);
    			AddCell(row, col, "totalColumn", "Totals", foreColor, backColor);
    			// Rows
    			foreColor = Color.Black;
    			row++;
    			foreach (var player in players)
    			{
    				backColor = GetBackColor(row);
    				AddCell(row, 0, "playerRank_" + player.ID, "", foreColor, backColor, ContentAlignment.MiddleLeft);
    				AddCell(row, 1, "playerName_" + player.ID, player.Name, foreColor, backColor, ContentAlignment.MiddleLeft);
    				AddCell(row, scoreBoardTable.ColumnCount, "playerTotal_" + player.ID, player.Total.ToString(), foreColor, backColor, ContentAlignment.MiddleRight);
    				row++;
    			}
    		}
    		private void GenerateScoreCells()
    		{
    			var foreColor = Color.Black;
    			int row = 1;
    			foreach (var player in players)
    			{
    				var backColor = GetBackColor(row);
    				int col = 2;
    				foreach (var game in games)
    				{
    					var score = GetScore(player, game);
    					AddCell(row, col, "score_" + player.ID + "_" + game.ID, score.ToString(), foreColor, backColor, ContentAlignment.MiddleRight, false);
    					col++;
    				}
    				row++;
    			}
    		}
    		static readonly Font defaultCellFont = new Font("Microsoft Sans Serif", 25, FontStyle.Bold);
    		private Label AddCell(int row, int col, string name, string text, Color foreColor, Color backColor, ContentAlignment textAlign = ContentAlignment.MiddleCenter, bool autoSize = true)
    		{
    			var label = new Label();
    			label.Name = name;
    			label.Text = text;
    			label.BackColor = backColor;
    			label.ForeColor = foreColor;
    			label.Font = defaultCellFont;
    			label.TextAlign = textAlign;
    			label.AutoSize = autoSize;
    			label.Margin = new Padding(0);
    			label.Dock = DockStyle.Fill;
    			scoreBoardTable.Controls.Add(label, col, row);
    			return label;
    		}
    		static Color GetBackColor(int row)
    		{
    			if (row % 2 == 0) //even row
    				return Color.Yellow;
    			else //odd row
    				return Color.LightGreen;
    		}
    	}
    }
