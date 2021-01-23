c#
using System;
using System.Threading.Tasks;
using System.Diagnostics;
public static class Debouncer
{
    private static Stopwatch _sw = new Stopwatch();
    private static int _debounceTime;
    private static int _callCount;
    /// <summary>
    ///     The <paramref name="callback"/> action gets called after the debounce delay has expired.
    /// </summary>
    /// <param name="input">this input value is passed to the callback when it's called</param>
    /// <param name="callback">the method to be called when debounce delay elapses</param>
    /// <param name="delay">optionally provide a custom debounce delay</param>
    /// <returns></returns>
    public static async Task DelayProcessing(this string input, Action<string> callback, int delay = 300)
    {
        _debounceTime = delay;
        _callCount++;
        int currentCount = _callCount;
        _sw.Restart();
        while (_sw.ElapsedMilliseconds < _debounceTime) await Task.Delay(10).ConfigureAwait(true);
        if (currentCount == _callCount)
        {
            callback(input);
            // prevent _callCount from overflowing at int.MaxValue
            _callCount = 0;
        }
    }
}
In your form code you can use it as follows:
c#
public partial class Form1 : Form
{
        
    public Form1()
    {
        InitializeComponent();
    }
    private async void textBox1_TextChanged(object sender, EventArgs e)
    {
        // set the text of label1 to the content of the 
        // calling textbox after a 300 msecs input delay.
        await ((TextBox)sender).Text
            .DelayProcessing(x => label1.Text = x);
    }
}
Note the use of the `async` keyword on the event handler here. Dont't leave it out.
**Explanation**
The static `Debouncer` Class declares an extension method `DelayProcessing` that extends the string type, so it can be tagged onto the `.Text` property of a `TextBox` component. The `DelayProcessing` method takes a labmda method that get's called as soon as the debounce delay elapses. In the example above I use it to set the text of `label` control, but you could do all sorts of other things here...
