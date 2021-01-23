    ...
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    Stream dataStream = response.GetResponseStream();
    wsResponseAsImg = Image.FromStream(response.GetResponseStream());
    byte[] imgBytes = turnImageToByteArray(wsResponseAsImg);
    string imgString = Convert.ToBase64String(imgBytes);
    string responseImgToBase64 = String.Format("data:image/jpeg;base64," + imgString);
     productDTO.thumbnail = responseImgToBase64;
     ...
     }
        private byte[] turnImageToByteArray(System.Drawing.Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
