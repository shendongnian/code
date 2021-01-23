     private async void appBarButton_Send_Click(object sender, EventArgs e)
      {
          Api api = new Api();
          SendMessage a = await api.SendMessage(contactNumber, textBox_Message.Text, textBox_Message);
          MessageBox.Show(a.message);
      }
