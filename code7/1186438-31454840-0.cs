            string path;
            foreach (var memberEntry in membersToCopy)
            {
                if (!Utils.TryParsePath(memberEntry .Body, out path))
                {
                    throw new ArgumentException("Include path not valid", "path");
                }
                context.Entry(_entityCopy).Member(path).CurrentValue = context.Entry(entity).Member(path).CurrentValue;
            }
