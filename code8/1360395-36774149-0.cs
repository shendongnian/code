    public class HelloWorldWeb : WebPart
        {
            protected override void CreateChildControls()
            {
                //table Cells Controls
                TextBox txt1 = new TextBox();
                txt1.Height = 19;
                TextBox txt2 = new TextBox();
                txt2.Height = 19;
                TextBox txt3 = new TextBox();
                txt3.Height = 19;
                DateTimeControl dt1 = new DateTimeControl();
                dt1.DateOnly = true;
                DateTimeControl dt2 = new DateTimeControl();
                dt2.DateOnly = true;
        
                //Declaration one Row and Five Cells(with controls)
                Table myTbl = new Table();
                TableRow tRow = new TableRow();
        
                TableCell tCellOne = new TableCell();
                tCellOne.Controls.Add(txt1);
                tRow.Cells.Add(tCellOne);
        
                TableCell tCellTwo = new TableCell();
                tCellTwo.Controls.Add(dt1);
                tRow.Cells.Add(tCellTwo);
        
                TableCell tCellThree = new TableCell();
                tCellThree.Controls.Add(dt2);
                tRow.Cells.Add(tCellThree);
        
                TableCell tCellFour = new TableCell();
                tCellFour.Controls.Add(txt2);
                tRow.Cells.Add(tCellFour);
        
                TableCell tCellFive = new TableCell();
                tCellFive.Controls.Add(txt3);
                tRow.Cells.Add(tCellFive);
        
                myTbl.Rows.Add(tRow);
        
                this.Controls.Add(new LiteralControl("<table class='ms-formbody' vAlign='top' >"));
        
                this.Controls.Add(new LiteralControl("<tr>"));
                this.Controls.Add(new LiteralControl("<td width='100' class='ms-formlabel' noWrap='nowrap' vAlign='top'>"));
                this.Controls.Add(myTbl);
                this.Controls.Add(btnAdd);
                this.Controls.Add(new LiteralControl("</td>"));
                this.Controls.Add(new LiteralControl("</tr>"));
        
                this.Controls.Add(new LiteralControl("</table>"));
        
                base.CreateChildControls();
            }
        
            void btnAdd_Click(object sender, EventArgs e)
            {
                CreateChildControls();
            }
        }
