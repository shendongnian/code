                byte[] data = File.ReadAllBytes("D:\\z.7z");
                File.WriteAllBytes("D:\\t.txt", data); // Requires System.IO
    
                byte[] newdata = File.ReadAllBytes("D:\\t.txt");
                File.WriteAllBytes("D:\\a.7z", newdata); // Requires System.IO
