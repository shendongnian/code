            this.Events().Closing.Subscribe(e =>
            {
                var dialog = Dialogs.ShowDialog("Close?", "Really Close?");
                var dispatcherFrame = new DispatcherFrame();
                dialog.Take(1).Subscribe(res => {
                    e.Cancel = res == DialogResult.Ok;
                    dispatcherFrame.Continue = false;
                });
                // this will process UI events till the above fires
                Dispatcher.PushFrame(dispatcherFrame);
            });
