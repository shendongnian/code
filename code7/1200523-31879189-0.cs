        private void Change<T>(T obj, Action<T> action)
            where T : Control
        {
            if (obj.InvokeRequired)
            {
                obj.Invoke(
                    new MethodInvoker(() => Change(obj, action)),
                    new object[] { null });
            }
            else
            {
                action(obj);
            }
        }
