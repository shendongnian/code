    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    namespace StackOverflow
    {
        public class TestControl : Control
        {
            static TestControl()
            {
                RegisterCommandBinding<TestControl>(NavigationCommands.FirstPage,
                    x => x.GoToFirstPage());
                RegisterCommandBinding<TestControl>(NavigationCommands.LastPage,
                    x => x.GoToLastPage(), x => x.CanGoToLastPage());
                DefaultStyleKeyProperty.OverrideMetadata(typeof(TestControl),
                    new FrameworkPropertyMetadata(typeof(TestControl)));
            }
            void GoToFirstPage()
            {
                Console.WriteLine("first page");
            }
            void GoToLastPage()
            {
                Console.WriteLine("last page");
            }
            bool CanGoToLastPage()
            {
                return true;  // Would put your own logic here obviously
            }
            public static void RegisterCommandBinding<TControl>(
                ICommand command, Action<TControl> execute) where TControl : class
            {
                RegisterCommandBinding<TControl>(command, execute, target => true);
            }
            public static void RegisterCommandBinding<TControl>(
                ICommand command, Action<TControl> execute, Func<TControl, bool> canExecute)
                where TControl : class
            {
                var commandBinding = new CommandBinding(command,
                    (target, e) => execute((TControl) target),
                    (target, e) => e.CanExecute = canExecute((TControl) target));
                CommandManager.RegisterClassCommandBinding(typeof(TControl), commandBinding);
            }
        }
    }
