        <div>
            <asp:Panel ID="pnlDynamicControl" runat="server">
            </asp:Panel>
            <br />
            <asp:Button ID="btnGetValue" runat="server" Text="Test" OnClientClick="return clickGetValue();" />
        </div>
    </form>
    <script type="text/javascript">
        function clickGetValue() {
            var control = document.getElementById('txtTest');
            // Better Ways
            var myControl = document.getElementById('<%=pnlDynamicControl.FindControl("txtTest").ClientID %>');
            // Check & Alert
            if (control != undefined) alert('Hardcode ID ways value is ' + control.value);
            // Check & Alert
            if (myControl != undefined) alert('C# findcontrol ways value is ' + myControl.value);
            return false;
        }
    </script>
