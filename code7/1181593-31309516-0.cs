    public class MyNameTransfom : ICSharpCode.SharpZipLib.Core.INameTransform
        {
    
            #region INameTransform 成员
    
            public string TransformDirectory(string name)
            {
                return null;
            }
    
            public string TransformFile(string name)
            {
                return Path.GetFileName(name);
            }
    
            #endregion
        }
    
        public partial class Default1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                ZipFileByCode();
            }
    
            /// <summary>
            /// 压缩打包文件
            /// </summary>
            public void ZipFileByCode()
            {
                MemoryStream ms = new MemoryStream();
                byte[] buffer = null;
    
                using (ZipFile file = ZipFile.Create(ms))
                {
                    file.BeginUpdate();
                    file.NameTransform = new MyNameTransfom();//通过这个名称格式化器，可以将里面的文件名进行一些处理。默认情况下，会自动根据文件的路径在zip中创建有关的文件夹。
    
                    file.Add(Server.MapPath("/Content/images/img01.jpg"));
                    file.Add(Server.MapPath("/Content/images/img02.jpg"));
                    file.CommitUpdate();
    
                    buffer = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(buffer, 0, buffer.Length);
                }
                Response.AddHeader("content-disposition", "attachment;filename=test.zip");
                Response.BinaryWrite(buffer);
                Response.Flush();
                Response.End();
            }
        }
