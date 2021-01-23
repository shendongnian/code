    public interface ICommand
    { 
    }
    class AboutCommand : ICommand
    {
    }
    internal class OptionsCommand : ICommand
    {
    }
    public abstract class MenuItem
    {
        private readonly ICommand command;
        protected MenuItem(ICommand command)
        {
            this.command = command;
        }
        public ICommand Command
        {
            get { return this.command; }
        }
    }
    public class OptionsMenuItem : MenuItem
    {
        public OptionsMenuItem(ICommand command)
            : base(command) { }
    }
    public class AboutMenuItem : MenuItem
    {
        public AboutMenuItem(ICommand command)
            : base(command) { }
    }
