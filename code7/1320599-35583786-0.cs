    <#@ template debug="false" hostspecific="false" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.Linq" #>
    <#@ output extension=".cs" #>
    using System;
    using System.Linq;
    using System.Collections.Generic;
    <#
    var maxArguments = 5;
    for(int i=0; i < maxArguments; ++i) {
        var argTypes = string.Join(", ",new string[i+1].Select((x,j)=>"T"+j).ToArray());
    #>
    public class StubSequenceBuilder<<#= argTypes #>>
    {
        private readonly Queue<Func<<#= argTypes #>>> _sequenceQueue = new Queue<Func<<#= argTypes #>>>();
        public StubSequenceBuilder<<#= argTypes #>> Next(Func<<#= argTypes #>> func)
        {
            _sequenceQueue.Enqueue(func);
            return this;
        }
    
        //...
    }
    <# } #>
