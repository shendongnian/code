    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MainFrameController controller = new MainFrameController();
            controller.DoWork();
            Callback(controller.DoAsyncWork());
        }
        private async void Callback(Task<HttpResponseMessage> task)
        {
            await task;
            Console.Write(task.Result);
            MainFrameController controller = new MainFrameController();
            controller.DoWork();
        }
    }
    internal class MainFrameController
    {
        public Task<HttpResponseMessage> DoAsyncWork()
        {
            return Task.Run(() => DoWork());
        }
        public HttpResponseMessage DoWork()
        {
            MyHttpClient myClient = new MyHttpClient();
            var task = myClient.RunAsyncGet();
            return task.Result;
        }
    }
