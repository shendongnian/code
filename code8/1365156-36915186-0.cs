            String text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse quis nisl vitae dolor tempus iaculis at id augue. Nullam metus mauris, viverra vitae tristique sed, pulvinar ac nulla.";
            text = text.Replace(" ", "");
            List<char> demo = text.ToCharArray().ToList();
            demo.Sort();
            string result = System.Text.Encoding.UTF8.GetString(demo.Select(c => (byte)c).ToArray());
