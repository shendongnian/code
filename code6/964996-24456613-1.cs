        case 17: // target Program's Create Button
            // Click : SendMessage -> PostMessage
            PostMessage(hWnd, WM.LBUTTONDOWN, 0, null);
            PostMessage(hWnd, WM.LBUTTONUP, 0, null);
            // used SendMessage : my program is stop
            // useing PostMessage : no problem 
            /******** here is Problem Code. (infinite loop) ********/
            int main = FindWindow(null, "Create Connecter"); // Parent
            int finish = 0;
            do {
                finish = FindWindowEx(main, 0, null, "Encode"); // MessageBox
                textBox1.AppendText("Wating....");
                System.Threading.Thread.Sleep(100);
            } while (finish == 0 || main == finish);
            textBox1.AppendText("Find MessageBox !!");
            /********************************************************/
            // OK Button Click in MessageBox
            hWnd = FindWindowEx(finish, 0, "Button", "OK");
            SendMessage(hWnd, WM.LBUTTONDOWN, 0, null);
            SendMessage(hWnd, WM.LBUTTONUP, 0, null);
