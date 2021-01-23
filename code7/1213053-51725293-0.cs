    @foreach (var resultItem in Model.SearchRequest.SearchResults)
                                {
                                    <tr>
                                        @{
                                            XmlDocument doc = new XmlDocument();
                                            doc.LoadXml(resultItem.CrossSiteUrl);
                                            XmlElement root = doc.DocumentElement;
                                            string path = String.Empty;
                                            string target = String.Empty;
                                            if (!string.IsNullOrEmpty(resultItem.CrossSiteUrl))
                                            {
                                                if (!string.IsNullOrEmpty(root.Attributes["url"].Value))
                                                {
                                                    path = root.Attributes["url"].Value;
                                                }
                                                if (!string.IsNullOrEmpty(root.Attributes["target"].Value))
                                                {
                                                    target = root.Attributes["target"].Value;
                                                }
                                            }
                                        }
                                        <td><a href="@path" target="@target">@resultItem.PageTitle</a></td>
                                        <td>@resultItem.DownloadTypeName</td>
                                        <td>@resultItem.ReleaseDate.ToShortDateString()</td>
                                        <td>@Convert.ToInt64(resultItem.FileSize).ConvertToSize()</td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">@resultItem.ShortDescription</td>
                                    </tr>
                                }
