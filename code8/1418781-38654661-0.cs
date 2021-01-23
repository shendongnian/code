    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using HtmlAgilityPack;
    
    namespace Test
    {
        public partial class Form1 : Form
        {
            private List<Bet> Bets;
        public Form1()
        {
            InitializeComponent();
            Form1_Load_1();
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }
        private Bet SelectedBet { get; set; }
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                SelectedBet = (Bet) dataGridView1.SelectedRows[0].DataBoundItem;
                if (SelectedBet.Odds.Count > 0)
                {
                    textBox1.Text = SelectedBet.Odds[0];
                    textBox2.Text = SelectedBet.Odds[1];
                    textBox3.Text = SelectedBet.Odds[2];
                }
            }
        }
        private void LoadInfo()
        {
            var url = "http://www.betexplorer.com/soccer/australia/northern-nsw/results/";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            Bets = new List<Bet>();
            // Lettura delle righe
            var Rows = doc.DocumentNode.SelectNodes("//tr");
            foreach (var row in Rows)
            {
                if (!row.GetAttributeValue("class", "").Contains("rtitle"))
                {
                    if (string.IsNullOrEmpty(row.InnerText))
                        continue;
                    var rowBet = new Bet();
                    foreach (var node in row.ChildNodes)
                    {
                        var data_odd = node.GetAttributeValue("data-odd", "");
                        if (string.IsNullOrEmpty(data_odd))
                        {
                            if (node.GetAttributeValue("class", "").Contains("first-cell"))
                            {
                                rowBet.Match = node.InnerText.Trim();
                                var matchTeam = rowBet.Match.Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries);
                                rowBet.Home = matchTeam[0];
                                rowBet.Host = matchTeam[1];
                            }
                            if (node.GetAttributeValue("class", "").Contains("result"))
                            {
                                rowBet.Result = node.InnerText.Trim();
                                var matchPoints = rowBet.Result.Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);
                                int help;
                                if (int.TryParse(matchPoints[0], out help))
                                {
                                    rowBet.HomePoints = help;
                                }
                                if (matchPoints.Length == 2 && int.TryParse(matchPoints[1], out help))
                                {
                                    rowBet.HostPoints = help;
                                }
                            }
                            if (node.GetAttributeValue("class", "").Contains("last-cell"))
                                rowBet.Date = node.InnerText.Trim();
                        }
                        else
                        {
                            rowBet.Odds.Add(data_odd);
                        }
                    }
                    if (!string.IsNullOrEmpty(rowBet.Match))
                        Bets.Add(rowBet);
                }
            }
        }
        private void Form1_Load_1()
        {
            LoadInfo();
            if (Bets.Count > 0)
            {
                SelectedBet = Bets[0];
                dataGridView1.DataSource = Bets;
                if (SelectedBet.Odds.Count > 0)
                {
                    textBox1.Text = SelectedBet.Odds[0];
                    textBox2.Text = SelectedBet.Odds[1];
                    textBox3.Text = SelectedBet.Odds[2];
                }
            }
        }
    }
    }
