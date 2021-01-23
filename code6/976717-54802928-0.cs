     MultipartMemoryStreamProvider stream = await this.Request.Content.ReadAsMultipartAsync();
                foreach (var st in stream.Contents)
                {
                    var fileBytes = await st.ReadAsByteArrayAsync();
                    string base64 = Convert.ToBase64String(fileBytes);
                    var contentHeader = st.Headers;
                    string filename = contentHeader.ContentDisposition.FileName.Replace("\"", "");
                    string filetype = contentHeader.ContentType.MediaType;
                }    
