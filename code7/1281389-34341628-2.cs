     private void FormMain_Load(object sender, EventArgs e)
            {
                NLog.Windows.Forms.RichTextBoxTarget target = new NLog.Windows.Forms.RichTextBoxTarget();
                target.Name = "RichTextBox";
                target.Layout = "${longdate} ${level:uppercase=true} ${logger} ${message}";
                target.ControlName = "richTextBoxMainLog";
                target.FormName = "FormMain";
                target.AutoScroll = true;
                target.MaxLines = 10000;
                target.UseDefaultRowColoringRules = false;
                target.RowColoringRules.Add(
                    new RichTextBoxRowColoringRule(
                        "level == LogLevel.Trace", // condition
                        "DarkGray", // font color
                        "Control", // background color
                        FontStyle.Regular
                    )
                );
                target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Debug", "Gray", "Control"));
                target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Info", "ControlText", "Control"));
                target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Warn", "DarkRed", "Control"));
                target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Error", "White", "DarkRed", FontStyle.Bold));
                target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Fatal", "Yellow", "DarkRed", FontStyle.Bold));
    
                AsyncTargetWrapper asyncWrapper = new AsyncTargetWrapper();
                asyncWrapper.Name = "AsyncRichTextBox";
                asyncWrapper.WrappedTarget = target;
    
                SimpleConfigurator.ConfigureForTargetLogging(asyncWrapper, LogLevel.Trace);
            }
