new USBCommunicationManager(this);
I was simply initializing it, not assigning it to any variable, that's why garbage collector later picked it up and ended the serial read thread.
Just changing it like this, solved the problem:
USBCommunicationManager usbCommunicationManager;
..
..
usbCommunicationManager = new USBCommunicationManager(this);
