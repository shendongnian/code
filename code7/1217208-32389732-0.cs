            private void GetUserDocs(string user_id)
            {
                using (SqlConnection connection = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand("SELECT id, title, alias, dt from dbo.user_works WHERE user_id = @user_id", connection))
                {
                    cmd.Parameters.AddWithValue("user_id", user_id);
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        // Check if the reader has any rows at all before starting to read.
                        if (reader.HasRows)
                        {
                            string doclist_html = "<div class=\"bookshelf_items\" id=\"bookshelf_items\" runat=\"server\">";
                            while (reader.Read())
                            {
                                string doc_id = reader["id"].ToString().Trim();
                                string title = reader["title"].ToString().Trim();
                                string alias = reader["alias"].ToString().Trim();
                                string dt = reader["dt"].ToString().Trim();
                                string date = DateTime.Parse(dt).ToShortDateString();
                                //build doc html
                                doclist_html = doclist_html + String.Format(
                                         "<div class='docbox'>" +
                                            "<div class='doc' contenteditable='true' id='doc_x{0}'>" +
                                                    "<div class='doc_title'>{1}" +
                                                    "</div>" +
                                                    "<div class='doc_txt'>{2}" +
                                                    "</div>" +
                                            "</div>" +
                                            "<div class='doc_date'>{3}</div>" +
                                                "<div class='doc_del' ID='del_{0}' runat='server'  />" +
                                                "<div class='doc_getlyt' ID='getlyt_{0}' runat='server' />" +
                                        "</div>",
                                        doc_id, title, alias, date);
                            }
                            doclist_html += "</div>";
                            bookshelf_items.InnerHtml = doclist_html;
                            string testhtml = bookshelf_items.InnerHtml;
                        }
                        else
                        {
                            //username not found
                            lbl_error.Text = ">>Failed to get documents<<";
                        }
                    }
                }
            }​
