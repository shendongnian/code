    using System;
    
    using FluentAssertions;
    using NUnit.Framework;
    
    namespace YourNamespace.Tests
    {
        [TestFixture]
        public class HighlightHelperTests
        {
            [Test]
            public void HighlightHelper_Int_Tests()
            {
                bool shouldHighlight = false;
    
                shouldHighlight = HighlightHelper.IsHighlighted(3);
                shouldHighlight.Should().BeFalse();
    
                shouldHighlight = HighlightHelper.IsHighlighted(14);
                shouldHighlight.Should().BeTrue();
            }
    		
            [Test]
            public void HighlightHelper_DateTime_Tests()
            {
                bool shouldHighlight = false;
    
                shouldHighlight = HighlightHelper.IsHighlighted(new DateTime(2016, 7, 13));
                shouldHighlight.Should().BeFalse();
    
                shouldHighlight = HighlightHelper.IsHighlighted(new DateTime(2016, 7, 14));
                shouldHighlight.Should().BeTrue();
            }
        }
    }
