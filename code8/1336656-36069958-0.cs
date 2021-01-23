    public IMessage SyncProcessMessage(IMessage msg) {
        if (//some condition is met) {
            return null;
        } else {
            IMessage returnMethod = m_next.SyncProcessMessage(msg);
            return returnMethod;
        }
    }
