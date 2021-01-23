    class Program
    {
        private static bool isInErrorState = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Starting smoke test\n\n");
            Playback.Initialize();
            Playback.PlaybackError += Playback_PlaybackError;
            try
            {
                CodedUITestInConsoleApp.CodedUI.CodedUITest1 test = new CodedUI.CodedUITest1();
                test.CodedUITestMethod1();
            }
            catch (Exception ex)
            {
                if (!isInErrorState)
                    CodedUITestMessage(ex.Message, false);
            }
            finally
            {
                Playback.Cleanup();
            }
            if (!isInErrorState)
                CodedUITestMessage("Successful smoke test.", true);
        }
        private static void Playback_PlaybackError(object sender, PlaybackErrorEventArgs e)
        {
            Playback.PlaybackError -= Playback_PlaybackError;
            isInErrorState = true;
            CodedUITestMessage("FAILURE running test.", false);
            Playback.StopSession();
        }
        private static void CodedUITestMessage(string message, bool isSuccess)
        {
            if (isSuccess)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
