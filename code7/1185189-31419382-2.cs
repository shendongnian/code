    IPAddress IP;
    int PortNum;
    if (IPAddress.TryParse(s[0], out IP)) // If it is a valid IP
        { MessageBox.Show("IP address in correct format"; }
    else { MessageBox.Show("IP address not in correct format"; }
    if (Int32.TryParse(s[1], out PortNum)) // If it is a valid Port Number
        { MessageBox.Show("Port Number in correct format"; }
    else { MessageBox.Show("Port Number not in correct format"; }
    
