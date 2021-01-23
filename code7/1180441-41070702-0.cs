     using TeleSharp.TL;
     using TLSharp;
     using TLSharp.Core;
     namespace TelegramSend
     {
        public partial class Form1 : Form
        {
          public Form1()
         {
             InitializeComponent();
         }
        TelegramClient client;
        private async void button1_Click(object sender, EventArgs e)
        {
            client = new TelegramClient(45145,  "d41271bd58b4a770640eb05632630630");
            await client.ConnectAsync();
        }
        string hash;
        private async void button2_Click(object sender, EventArgs e)
        {
            hash = await client.SendCodeRequestAsync(textBox1.Text);
            //var code = "<code_from_telegram>"; // you can change code in debugger
            
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            var user = await client.MakeAuthAsync(textBox1.Text, hash, textBox2.Text);
        }
        private async void button4_Click(object sender, EventArgs e)
        {
            //get available contacts
            var result = await client.GetContactsAsync();
            //find recipient in contacts
            var user = result.users.lists
                .Where(x => x.GetType() == typeof(TLUser))
                .Cast<TLUser>()
                .Where(x => x.first_name == "ZRX");
            if (user.ToList().Count != 0)
            {
                foreach (var u in user)
                {
                    if (u.phone.Contains("3965604"))
                    {
                        //send message
                        await client.SendMessageAsync(new TLInputPeerUser() { user_id = u.id }, textBox3.Text);
                    }
                }
            }
        }
     }}
