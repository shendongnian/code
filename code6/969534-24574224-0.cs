      protected void btntest_Click(object sender, EventArgs e)
        {
            var boardsJsonLink = "https://a.4cdn.org/boards.json";
            WebClient wc = new WebClient();
            var json = wc.DownloadString(boardsJsonLink);
            var data = JsonConvert.DeserializeObject<TestObj>(json);
            Response.Write(@"<table  width='300px' border='1' cellpadding='2' cellspacing='2'> <tr>
                <td>
                    Board</td>
                <td>
                    Title</td>
                <td>
                   ws_Board</td>
                <td>
                    perPage</td>
                <td>
                   pages</td>
            </tr>");
            foreach (var itm in data.boards)
            {
                string board = itm.board;
                string title = itm.title;
                int ws_board = itm.ws_board;
                int per_page = itm.per_page;
                int pages = itm.pages;
                Response.Write(@"<tr>
                <td>"+board+"</td><td>"+Title+"</td><td> "+ws_board+"</td><td> "+ per_page+"</td> <td>"+ pages+"</td></tr>");
            }
            Response.Write(@"</table>");
        }
    public class Board
    {
        public string board { get; set; }
        public string title { get; set; }
        public int ws_board { get; set; }
        public int per_page { get; set; }
        public int pages { get; set; }
    }
    
    public class TestObj
    {
        public List<Board> boards { get; set; }
    }
