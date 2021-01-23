    using System;
    using Autofac;
    using Autofac.Features.Indexed;
    namespace AutoFac
        {
            
            class Program
            {
                static void Main(string[] args)
                {
                    var builder = new ContainerBuilder();
                    builder.RegisterType<OnlineState>().Keyed<IDeviceState>("online");
                    builder.RegisterType<OfflineState>().Keyed<IDeviceState>("offline");
        
                    builder.RegisterType<Modem>().AsImplementedInterfaces();
        
                    var container = builder.Build();
        
                    var r = container.Resolve<IModem>();
        
                    r.print();
        
                }
            }
        public interface IDeviceState
            {
                string Get();
            }
            public class OnlineState : IDeviceState
            {
                public string Get()
                {
                    return "OnlineState";
                }
            }
            public class OfflineState : IDeviceState
            {
                public string Get()
                {
                    return "OfflineState";
                }
            }
            public class Modem  : IModem
            {
                 readonly IIndex<string, IDeviceState> _states;
                 private readonly IDeviceState _deviceState;
                 public Modem(IIndex<string, IDeviceState> states)
                 {
                     _states = states;
                     _deviceState = _states["online"];
                    //_deviceState = _states["offline"];
                 }
    
                 public void print()
                 {
                     Console.WriteLine(_deviceState.Get());
                 }
            }
    
            public interface IModem
            {
                void print();
            }
        }
