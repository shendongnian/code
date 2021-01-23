    using System;
    using System.Windows.Forms;
    using System.Timers;
    namespace WindowsFormsApplication1
    {
      public partial class Form1 : Form
      {
        private System.Timers.Timer machineTimer = new System.Timers.Timer();
        // These are our Machine States
        private const int BEGIN_PLAY = 0;
        private const int HUMAN_PLAYER_TURN = 1;
        private const int AI_PLAYER_TURN = 2;
        // This is the Current Machine State
        private int currentPlayer = BEGIN_PLAY;
        // Flag that lets us know that the Click Event Handler is Enabled
        private bool waitForClick = false;
        // The AI members, for example 100 of them
        private const int AIcount = 100;
        private object[] AIplayer = new object[AIcount];
        private int AIcurrentIndex = 0;    // values will be 0 to 99
        public Form1()
        {
            InitializeComponent();
            this.Show();
            // The Timer Interval sets the pace of the state machine. 
            // For example if you have a lot of AIs, then make it shorter
            //   100 milliseconds * 100 AIs will take a minimum of 10 seconds of stepping time to process the AIs
            machineTimer.Interval = 100;  
            machineTimer.Elapsed += MachineTimer_Elapsed;
           
            MessageBox.Show("Start the Game!");
            machineTimer.Start();
        }
        private void MachineTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Stop the Timer
            machineTimer.Stop();
            try
            {
                // Execute the State Machine
                State_Machine();
                // If no problems, then Restart the Timer
                machineTimer.Start();
            }
            catch (Exception stateMachineException)
            {
                // There was an Error in the State Machine, display the message
                // The Timer is Stopped, so the game will not continue
                if (currentPlayer == HUMAN_PLAYER_TURN)
                {
                    MessageBox.Show("Player Error: " + stateMachineException.Message, "HUMAN ERROR!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (currentPlayer == AI_PLAYER_TURN)
                {
                    MessageBox.Show("Player Error: " + stateMachineException.Message, "AI ERROR!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Machine Error: " + stateMachineException.Message, "Machine ERROR!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void State_Machine()
        {
            // This routine is executing in the Timer.Elapsed Event's Thread, not the Main Form's Thread
            switch (currentPlayer)
            {
                case HUMAN_PLAYER_TURN:
                    Play_Human();
                    break;
                case AI_PLAYER_TURN:
                    Play_AI();
                    break;
                default:
                    Play_Begin();
                    break;
            }
        }
        private void Play_Human()
        {
            // This routine is executing in the Timer.Elapsed Event's Thread, not the Main Form's Thread
            // My Turn!
            if (!waitForClick)
            {
                // Please Wait until I take a card...
                // I am using this.Invoke here because I am not in the same thread as the main form GUI
                // If we do not wrap the code that accesses the GUI, we may get threading errors.
                this.Invoke((MethodInvoker)delegate
                {
                    pictureBox1.Click += PictureBox1_Click;
                });
                // set this flag so we do not re-enable the click event until we are ready next time
                waitForClick = true;
            }
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            // This routine is executing in the Main Form's Thread, not the Timer's Thread
            // Stop the game for a little bit so we can process the Human's turn
            machineTimer.Stop();
            // Disable the Click Event, we don't need it until next time
            pictureBox1.Click -= PictureBox1_Click;
            waitForClick = false;
            // To Do:  Human's Turn code...
            // Let the AI Play now
            currentPlayer = AI_PLAYER_TURN;
            machineTimer.Start();
        }
        private void Play_AI()
        {
            // This routine is executing in the Timer.Elapsed Event's Thread, not the Main Form's Thread
            if (AIcurrentIndex < AIcount)
            {
                // If we do not wrap the code that accesses the GUI, we may get threading errors.
                this.Invoke((MethodInvoker)delegate
                {
                    // To Do:  AI Player's Turn code...
                });
                // Advance to the next AI
                AIcurrentIndex++;
            }
            else
            {
                // Reset to the beginning
                AIcurrentIndex = 0;
                currentPlayer = BEGIN_PLAY;
            }
        }
        private void Play_Begin()
        {
            // This routine is executing in the Timer.Elapsed Event's Thread, not the Main Form's Thread
            // If we do not wrap the code that accesses the GUI, we may get threading errors.
            this.Invoke((MethodInvoker)delegate
            {
                // ... do stuff to setup the game ...
            });
            // Now let the Human Play on the next Timer.Elapsed event
            currentPlayer = HUMAN_PLAYER_TURN;
            // After the Human is done, start with the first AI index
            AIcurrentIndex = 0;
        }
      }
    }
