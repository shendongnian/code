    public static class SerialObservableExtensions
        {
        static readonly Logger log = LogManager.GetCurrentClassLogger();
        /// <summary>
        ///     Captures the <see cref="System.IO.Ports.SerialPort.DataReceived" /> event of a serial port and returns an
        ///     observable sequence of the events.
        /// </summary>
        /// <param name="port">The serial port that will act as the event source.</param>
        /// <returns><see cref="IObservable{Char}" /> - an observable sequence of events.</returns>
        public static IObservable<EventPattern<SerialDataReceivedEventArgs>> ObservableDataReceivedEvents(
            this ISerialPort port)
            {
            var portEvents = Observable.FromEventPattern<SerialDataReceivedEventHandler, SerialDataReceivedEventArgs>(
                handler =>
                    {
                    log.Debug("Event: SerialDataReceived");
                    return handler.Invoke;
                    },
                handler =>
                    {
                    // We must discard stale data when subscribing or it will pollute the first element of the sequence.
                    port.DiscardInBuffer();
                    port.DataReceived += handler;
                    log.Debug("Listening to DataReceived event");
                    },
                handler =>
                    {
                    port.DataReceived -= handler;
                    log.Debug("Stopped listening to DataReceived event");
                    });
            return portEvents;
            }
        /// <summary>
        ///     Gets an observable sequence of all the characters received by a serial port.
        /// </summary>
        /// <param name="port">The port that is to be the data source.</param>
        /// <returns><see cref="IObservable{char}" /> - an observable sequence of characters.</returns>
        public static IObservable<char> ReceivedCharacters(this ISerialPort port)
            {
            var observableEvents = port.ObservableDataReceivedEvents();
            var observableCharacterSequence = from args in observableEvents
                                              where args.EventArgs.EventType == SerialData.Chars
                                              from character in port.ReadExisting()
                                              select character;
            return observableCharacterSequence;
            }
    }
