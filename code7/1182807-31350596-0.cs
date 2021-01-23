            Byte[] answer = new Byte[1024];
            string sAnswer = "";
            int bytesRead;
            while (true)
            {
                bytesRead = myNetworkStream.Read(answer, 0, answer.Length);
                sAnswer = sAnswer + Encoding.UTF8.GetString(answer, 0, bytesRead);
                if (sAnswer.Contains("#END#")) break;
            }
            int i = sAnswer.IndexOf("#END#");
            sAnswer = sAnswer.Substring(0, i);
