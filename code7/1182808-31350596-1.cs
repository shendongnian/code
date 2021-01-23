            Byte[] answer = new Byte[1024];
            string sAnswer = "";
            int bytesRead;
            MemoryStream ms = new MemoryStream();
            while (true)
            {
                bytesRead = myNetworkStream.Read(answer, 0, answer.Length);
                ms.Write(answer, 0, bytesRead);
                sAnswer = Encoding.UTF8.GetString(ms.ToArray());
                if (sAnswer.Contains("#END#")) break;
            }
            int i = sAnswer.IndexOf("#END#");
            sAnswer = sAnswer.Substring(0, i);
