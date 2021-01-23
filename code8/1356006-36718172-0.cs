     private void button11_Click(object sender, EventArgs e)
        {
            XmlNodeList comTimeoutNotificationList = doc.GetElementsByTagName("DEFINITION-REF");
            int NodeListCount = comTimeoutNotificationList.Count;
			foreach (XmlNode node in comTimeoutNotificationList)
            {
                if (node.InnerText == "/AUTOSAR/Com/ComConfig/ComSignal")
                {
                    if(node.PreviousSibling.Name == "SHORT-NAME")
                    shortName = node.PreviousSibling.InnerText;
                }
                if (node.InnerText == "/AUTOSAR/Com/ComConfig/ComSignal/ComTimeoutNotification")
                {
                    node.NextSibling.InnerText ="ComTout_" +  shortName;
                    listBox1.Items.Add(node.NextSibling.InnerText);
                }
                else if(node.InnerText == "/AUTOSAR/Com/ComConfig/ComSignal/ComNotification")
                {
                    node.NextSibling.InnerText = "ComNoti_" + shortName;
                    listBox1.Items.Add(node.NextSibling.InnerText);
                }
                else if(node.InnerText == "/AUTOSAR/Com/ComConfig/ComSignal/ComInvalidNotification")
                {
                    node.NextSibling.InnerText = "ComInval" + shortName;
                    listBox1.Items.Add(node.NextSibling.InnerText);
                }
            }
		
		}
		
