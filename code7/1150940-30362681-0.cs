    // WhateverHub
    public override Task OnConnected()
    {
        //.. do whatever
        return base.OnConnected()
    }
    
    public void AfterConnected()
    {
        // whatever if/else first user/last user logic
        // if(stuff)
        {
            Clients.Caller.hello("message")
        }
    }
----------
    var proxy= $.connection.whateverHub;
    proxy.client.hello = function(message) {
        // last step in event chain
    }
    
    $.connection.hub.start().done(function () {
        proxy.server.afterConnected() // call AfterConnected() on hub
    });
