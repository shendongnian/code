    //Just a snippet, you can use the FullName or Name to determine which
    //control it belongs to...
            Type t = (sender).GetType();
            switch (t.FullName)
            {
                case "Namespace.Control1":
                    break;
                case "Namespace.Control2":
                    break;
            }
