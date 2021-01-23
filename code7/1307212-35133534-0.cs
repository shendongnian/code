                   var fileRef = listItem.File.ServerRelativeUrl;
                  var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(clientContext, fileRef);
                    var stream = fileInfo.Stream;
                    IList<byte> content = new List<byte>();
                    int b;
                    while ((b = fileInfo.Stream.ReadByte()) != -1)
                    {
                        content.Add((byte)b);
                    }
                    byte[] barray = content.ToArray();
